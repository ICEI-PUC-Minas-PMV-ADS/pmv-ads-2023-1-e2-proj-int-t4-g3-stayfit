let squares = document.querySelectorAll(".square");

squares.forEach(square => {
	square.addEventListener("click", function () {
		this.classList.toggle("clicked");
	});
});
