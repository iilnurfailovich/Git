function initValues() {
    window.value1 = document.getElementById('x1').value.trim();
    window.value2 = document.getElementById('x2').value.trim();
    window.x1 = parseInt(value1);
    window.x2 = parseInt(value2);
}

function buttonClick() {
    if (checkValid())
        document.getElementById('result').innerHTML = "x1 + x2 = " + (x1 + x2);
}

function checkValid() {
    initValues();

    let isValid = false;

    if (value1.length === 0 || value2.length === 0)
        alert("Поля x1 и x2 должны быть заполнены");

    else if (Number.isNaN(x1) || Number.isNaN(x2))
        alert("В полях х1 и х2 должны быть введены числовые значения");

    else isValid = true;

    return isValid;
}

function getResult(sum) {
    if (checkValid()) {
        let x3 = (x1 > x2) ? x1 : x2;
        let x4 = (x1 < x2) ? x1 : x2;

        for (let i = x4 + 1; i <= x3; i++)
            x4 = sum ? x4 + i : x4 * i;

        document.getElementById('result').innerHTML = x4;
    }
}

function primeNumber() {
    if (checkValid()) {
        let x3 = (x1 > x2) ? x1 : x2;
        let x4 = (x1 < x2) ? x1 : x2;
        let divider = 0;
        let arr = [];
        lable : for (let i = x4; i <= x3; i++) {
            for (let j = 1; j <= i; j++) {
                if (i % j === 0)
                    divider++;
                if (divider > 2) {
                    divider = 0;
                    continue lable;
                }
            }
            if (divider === 2) {
                arr.push(i);
            }
            divider = 0;
        }
        document.getElementById('result').innerHTML = arr;
    }
}

function remove() {
    document.getElementById('x1').value = null;
    document.getElementById('x2').value = null
}

	

