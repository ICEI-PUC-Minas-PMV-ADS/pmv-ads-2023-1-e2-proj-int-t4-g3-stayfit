
document.getElementById("enviarTeste").addEventListener("click", enviar);
document.getElementById("addTreino").addEventListener("click", adicionarLista);

   
function adicionarLista() {
    alert("Click");
    let nrepeticoes = document.getElementById("nrepeticoes").value;
    let series = document.getElementById("series").value;
    let restTime = document.getElementById("restTime").value;
    let restBetween = document.getElementById("restBetween").value;
    let distance = document.getElementById("distance").value;
    let weight = document.getElementById("weight").value;
    let ExercicioId = document.getElementById("ExercicioId").value;
    let FichaId = document.getElementById("FichaId").value;

    if (localStorage.getItem("TreinosLocal") == null) {
        let treino = [{
            "repetitionNumber": nrepeticoes,
            "series": series,
            "restTime": restTime,
            "restBetween": restBetween,
            "distance": distance,
            "weight": weight,
            "exercicioId": ExercicioId,
            "exercicio": null,
            "fichaId": FichaId
        }]; 

        localStorage.setItem("TreinosLocal", JSON.stringify(treino))
    }
}


function enviar() {
    var treino = [{       
        "repetitionNumber": 100,
        "series": 3,
        "restTime": 1,
        "restBetween": 2,
        "distance": null,
        "weight": null,
        "exercicioId": 2,
        "exercicio": null,
        "ficha": null
    },
        {
            "repetitionNumber": 255,
            "series": 3,
            "restTime": 1,
            "restBetween": 2,
            "distance": null,
            "weight": null,
            "exercicioId": 2,
            "exercicio": null,
            "ficha": null
        }];
    fetch('/Treino/teste', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify(treino)
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
        console.warn('BLAH BLAH BLAH', error);
    });

}