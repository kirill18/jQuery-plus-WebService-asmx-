function create_control() {
    var e;
    e=document.createElement('table');
    e.setAttribute("width","100");
    e.setAttribute("height","100");
    e.setAttribute("border","1");
    e.style.position = 'absolute';
    document.body.appendChild(e);
}


var tr11 = document.getElementById('tr11'); //берем первую строку
var table = document.getElementById('table1');
var tr31 = document.createElement('tr'); //создаем еще строку
var td31 = document.createElement('td'); td31.innerHTML = '31'; //создаем столбец
var td32 = document.createElement('td'); td32.innerHTML = '32'; //создаем еще столбец
//tr11.appendChild(td31); так можно добавить в первую строку столбец
tr31.appendChild(td31); //кладем в новосозданную строку первый новосозданный столбец
tr31.appendChild(td32); //кладем в новосозданную строку второй новосозданный столбец
table.appendChild(tr31); //кладем в таблицу новосозданную строку (последней)
