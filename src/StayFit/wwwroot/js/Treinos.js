
document.getElementById("enviarTeste").addEventListener("click", enviar);
document.getElementById("addTreino").addEventListener("click", adicionarLista);

var e = document.getElementById("ExercicioId");
var value = e.value;
document.querySelector(".teste").innerHTML = e.options[e.selectedIndex].text;
function adicionarLista() {
    
    let nrepeticoes = document.getElementById("nrepeticoes").value;
    let series = document.getElementById("series").value;
    let restTime = document.getElementById("restTime").value;
    let restBetween = document.getElementById("restBetween").value;
    let distance = document.getElementById("distance").value;
    let weight = document.getElementById("weight").value;
    let ExercicioId = document.getElementById("ExercicioId").value;
    let FichaId = document.getElementById("FichaId").value;

    let treino = {
            
            "repetitionNumber": nrepeticoes,
            "series": series,
            "restTime": restTime,
            "restBetween": restBetween,
            "distance": distance,
            "weight": weight,
            "exercicioId": ExercicioId,
            "exercicio": null,
            "FichaId":FichaId,
        }; 

    let dataLocal = localStorage.getItem("TreinosLocal");
    if (dataLocal == null || dataLocal == undefined) {
        localStorage.setItem("TreinosLocal", JSON.stringify([treino]))
    } else {
        data = JSON.parse(dataLocal)
        data.push(treino);
        localStorage.setItem("TreinosLocal", JSON.stringify(data))
    }

    ListarTreino();
}


function enviar() {
    let treinos = JSON.parse(localStorage.getItem("TreinosLocal"));

    /*
    let treinos = [{       
        "repetitionNumber": 3,
        "series": 3,
        "restTime": 1,
        "restBetween": 2,
        "distance": null,
        "weight": null,
        "exercicioId": 2,
        "exercicio": null,
        "FichaId": 1
    },
        {
            "repetitionNumber": 335,
            "series": 3,
            "restTime": 1,
            "restBetween": 2,
            "distance": null,
            "weight": null,
            "exercicioId": 2,
            "exercicio": null,
            "FichaId": 1
        }];
        */
    fetch('/Treino/teste', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify(treinos)
    }).then(function (response) {
        if (response.ok) {
            alert("teste"+ response);
            return response.json();
        }
        return Promise.reject(response);
    }).then(data => {
        let dados = JSON.parse(data);
        console.log('Success:', dados);
    }).catch(function (error) {
        console.warn(error);
    });

}

function ListarTreino() {
    let place_treinos = '';
    let data = JSON.parse(localStorage.getItem("TreinosLocal"));
    if (data !== null) {
        data.forEach(treino =>  {
            place_treinos += ` 
            <div>
                <h4><span>${treino.exercicioId} </span></h4>
                <h5><span>Repeticoes: ${treino.repetitionNumber} </span><span>Series: ${treino.series}</span> </h5>
            </div>`
        });
    }

    document.querySelector('.treinos-card').innerHTML = place_treinos;
    place_treinos = ''
}