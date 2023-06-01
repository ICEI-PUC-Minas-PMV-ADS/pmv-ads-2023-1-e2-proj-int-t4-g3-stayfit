﻿ 
function updateAnamnese() {
   
    let Altura = document.getElementById("Altura").value;
    let Peso = document.getElementById("Peso").value;    
    let IsTomaMedicamentos = document.getElementById("IsTomaMedicamentos");
    let objetivos = document.getElementById("Objetivos").value;
    let medicamentos = document.getElementById("Medicamentos").value;
    let observacoes = document.getElementById("Observacoes").value;
    let deficiencia = document.getElementById("Deficiencia").value;
    let isProblemaSaude = document.getElementById("IsProblemaSaude");
    let isDeficiente = document.getElementById("IsDeficiente");
    let isFumante = document.getElementById("IsFumante");
    let isPraticante = document.getElementById("IsPraticante");
    let problemaSaude = document.getElementById("ProblemaSaude").value;

    let isMed = isTomaMedicamentos.options[isTomaMedicamentos.selectedIndex].value;
    let isFum = isFumante.options[isFumante.selectedIndex].value;
    let isDef = isDeficiente.options[isDeficiente.selectedIndex].value;
    let isPrat = isPraticante.options[isPraticante.selectedIndex].value;
    let isPSau = isProblemaSaude.options[isProblemaSaude.selectedIndex].value;
     
    let avaliacao = {
        "objetivos": objetivos,
        "peso": Peso,
        "altura": Altura,
        "isPraticante": isPrat,
        "isTomaMedicamentos": 0,
        "medicamentos": medicamentos,
        "isFumante": 1,
        "isProblemaSaude": 0,
        "problemaSaude": problemaSaude,
        "isDeficiente": isDef,
        "deficiencia": deficiencia,
        "observacoes": observacoes,

    };


    //let avalia = {
    //    "objetivos": "TESTE",
    //    "peso": 150,
    //    "altura": 190,
    //    "isPraticante": false,
    //    "isTomaMedicamentos": null,
    //    "medicamentos": null,
    //    "isFumante": null,
    //    "isProblemaSaude": null,
    //    "problemaSaude": null,
    //    "isDeficiente": null,
    //    "deficiencia": null,
    //    "observacoes": null,
    //    "circunferenciaBracoDir": null,
    //    "circunferenciaBracoEsq": null,
    //    "circunferenciaAnteBracoDir": null,
    //    "circunferenciaAnteBracoEsq": null,
    //    "circunferenciaAbdomen": null,
    //    "circunferenciaQuadril": null,
    //    "circunferenciaCintura": null,
    //    "circunferenciaCoxaEsq": null,
    //    "circunferenciaCoxaDir": null,
    //    "circunferenciaPernaEsq": null,
    //    "circunferenciaPernaDir": null,
    //    "percentualGordura": null,
    //    "massaMagra": null,
    //    "massaGorda": null,
    //    "massaMuscular": null,
    //    "massaOssea": null,
    //    "massaResidual": null,
    //    "frecCardRepouso": null,
    //    "frecCardM1": null,
    //    "frecCardM2": null,
    //    "frecCardM3": null,
    //    "frecCardMaxima": null,
    //    "voMax": null,
    //    "tempoEsteira": null

    //};
  
    console.log(avaliacao);

    fetch('/Instrutor/UpdateAnamnese', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify(avaliacao)
    }).then(function (response) {
        if (response.ok) {
            alert("teste " + response);
            alert(isFumante);
            return response.json();
        }
        return Promise.reject(response);
    }).then(data => {
        let dados = JSON.parse(data);
        console.log('Success:', dados);
        if (data) {
            
            //window.location.replace('http://localhost:5247/Instrutor/Av');
        }
    }).catch(function (error) {
        console.warn(error);
    });

}

function ListarTreino() {
    let place_treinos = '';
    let data = JSON.parse(localStorage.getItem("TreinosLocal"));
    let dataEx = JSON.parse(localStorage.getItem("NomeExercicios"));
    if (data !== null) {
        data.forEach((treino, index) => {
            place_treinos += ` 
            <div>
                <h4><span>${dataEx[index]} </span></h4>
                <h5><span>Repeticoes: ${treino.repetitionNumber} </span><span>Series: ${treino.series}</span> </h5>
            </div>`
        });
    }

    document.querySelector('.treinos-card').innerHTML = place_treinos;
    place_treinos = ''
}