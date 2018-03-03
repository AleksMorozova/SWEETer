// Write your Javascript code.
window.onload = function () {
    var hide = document.getElementById('HideForm');
    var show = document.getElementById('ShowForm');
    var form = document.getElementById('Addfeed');

    hide.onclick = function () {
        form.classList.add('hidden');
        hide.classList.add('hidden');
        show.classList.remove('hidden');
    }
    show.onclick = function () {
        form.classList.remove('hidden');
        hide.classList.remove('hidden');
        show.classList.add('hidden');
    }
}
function limitTextPost(button, counter, limitField, limitNum) {
    var diff = limitNum - limitField.value.length;
    if (diff < 0) {

        counter.innerText = "The number of characters left: " + diff;
        button.disabled = true;
    }
    else
    {
        counter.innerText = "The number of characters lefts: " + diff;
        button.disabled = false;
    }
}