const input = document.getElementById('file-input');
const video = document.getElementById('video');

const previewNomeExercicio = document.getElementById('previewNomeExercicio');
const nomeExercicio = document.getElementById('nomeExercicio');

//const videoSource = document.createElement('source');
let preview = document.getElementById('preview');

/*
nomeExercicio.addEventListener('change', function () {
    alert("teste")
    previewNomeExercicio.innerHTML = nomeExercicio.value;
});
*/
input.addEventListener('change', function () {
    const files = this.files || [];

    if (!files.length) return;

    const reader = new FileReader();

    reader.onload = function (e) {
        preview.innerHTML = `<video style="width:100%" controls="controls">
                               <source src="${e.target.result}" type="video/mp4" />
                             </video>`;
      /*  videoSource.setAttribute('src', e.target.result);
        video.appendChild(videoSource);
        video.load();
        video.play();
        */
    };

    reader.onprogress = function (e) {
        console.log('progress: ', Math.round((e.loaded * 100) / e.total));
    };

    reader.readAsDataURL(files[0]);
});