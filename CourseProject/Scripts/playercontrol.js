player = new Audio("music/BLACKPINK-Kill This Love(1).mp3");

area1 = document.getElementById("area1");
area2 = document.getElementById("area2");
area3 = document.getElementById("area3");
area4 = document.getElementById("area4");

area1.addEventListener('click', function () {
    player.pause();
    player = new Audio("music/BLACKPINK-Kill This Love(1).mp3")
    player.play();
}, false);

area2.addEventListener('click', function () {
    player.pause();
    player = new Audio("music/BLACKPINK-DDU-DU DDU-DU (뚜두뚜두) (Korean Ver.).mp3");
    player.play();
}, false);
area3.addEventListener('click', function () {
    player.pause();
    player = new Audio("music/BLACKPINK-Forever Young.mp3");
    player.play();
}, false);
area4.addEventListener('click', function () {
    player.pause();
    player = new Audio("music/BLACKPINK-AS IF IT'S YOUR LAST (마지막처럼).mp3");
    player.play();
}, false);



