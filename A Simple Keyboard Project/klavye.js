const keys    = document.querySelectorAll('.container .satir span'),
      keyPad  = document.querySelector('.container'),
      display = document.querySelector('.ekran');

let caps = document.querySelector('.container .satir .caps_tusu');
let capsLockMode = true;
window.onload = function(){
    caps.classList.toggle("aktif");
    keyPad.classList.toggle("uppercase");
}

if(keys && keyPad && display)
{
    keys.forEach(container=>
    {
        container.addEventListener('click', function()
        {
            if(this.classList.contains('caps_tusu'))
            {
                this.classList.toggle('aktif');
                keyPad.classList.toggle('uppercase');

                capsLockMode ? capsLockMode = false : capsLockMode = true;
            }
            else if (this.classList.contains('sil_tusu'))
            {
                let str = display.innerText;
                display.innerText = str.substring(0, (str.length-1));
            }
            else if (this.classList.contains('enter_tusu'))
            {
                display.innerText = this.dataset.key;
            }
            else
            {
                if(capsLockMode)//Ekrana yazı yazmayı sağlayan kod:
                {
                    display.innerText += this.dataset.key.toUpperCase(); //dataset ile data-* attribute'üne ulaşılabilir ya da..
                }else{
                    display.innerText += this.dataset.key.toLowerCase(); //getAttribute(data-key) ile de ulaşılabilir.
                }
            }
        });
    });
}

function diger(hangisi){
    var i;
    var x = document.getElementsByClassName("container");
    for(i = 0; i < x.length; i++){
        x[i].style.display = "none";
    }
    document.getElementById(hangisi).style.display = "block";
}
