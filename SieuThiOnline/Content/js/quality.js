let minus = document.querySelector('.minus');
let plus = document.querySelector('.plus');
let qtyInput = document.querySelector('.quality input');

minus.onclick = function () {
    if (qtyInput.value <=1) {
        qtyInput.value = 1;
    } else {
        qtyInput.value--;
    }
}

plus.onclick = function () {
    qtyInput.value++;
}


