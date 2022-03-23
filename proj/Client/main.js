import { CityMun } from "./CityMun.js";


//naslov
let l = document.createElement("h1");
l.innerHTML = "Weather&AirQ";
l.className = "naslov";
document.body.appendChild(l);

//uvodna forma
let divEl = document.createElement("div");
divEl.className = "divEl";
document.body.appendChild(divEl);
let divEl1 = document.createElement("div");
divEl1.className = "divEl1";
divEl.appendChild(divEl1);
let divEl2 = document.createElement("div");
divEl2.className = "divEl2";
divEl.appendChild(divEl2);
let divEl3 = document.createElement("div");
divEl3.className = "divEl3";
divEl.appendChild(divEl3);

l = document.createElement("label");
l.innerHTML="City/Municipality:";
divEl1.appendChild(l);
let select = document.createElement("select");
select.className="citymunselect";
divEl1.appendChild(select);

var op;
var lcities = [];
fetch("https://localhost:5001/CityMun/getcitymun")
.then(p=>{
    p.json().then(cities => {
        cities.forEach(city => {
            for(var i in city)
            {
                lcities.push(city[i]);
            }
        })

        let duzina = lcities.length;
        for(var i=1; i<duzina; i+=3)
        {
            op = document.createElement("option");
            op.value=lcities[i];
            op.innerHTML = lcities[i];
            select.appendChild(op);
        }       

    })
})

let btn = document.createElement("button");
btn.className = "dugme1";
btn.innerHTML="Add New City/Mun";
divEl2.appendChild(btn);
let d = document.createElement("div");
d.className = "divEl1";
document.body.appendChild(d); 
btn.onclick=(ev) => CityMun.crtajFormuZaDodavanje(d);


let btnShowCity = document.createElement("button");
btnShowCity.className = "dugme1";
btnShowCity.innerHTML="Show City/Mun";
divEl3.appendChild(btnShowCity);
btnShowCity.onclick = (ev) => CityMun.prikaziGrad(d);



