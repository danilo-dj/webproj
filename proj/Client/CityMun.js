export class CityMun {

    constructor(ime, zipcode){
        this.id = null;
        this.ime = ime;
        this.zipcode = zipcode;
    }

    static prikaziGrad(host)
    {
        let divGrad = document.createElement("div");
        divGrad.className="divGrad";
        host.appendChild(divGrad);
        
        let h = document.createElement("h3");
        h.innerHTML = document.querySelector(".citymunselect").value;
        divGrad.appendChild(h);

        let d = document.createElement("div");
        d.clas = "divE1";
        divGrad.appendChild(d);
        
        let l = document.createElement("label");
        l.innerHTML="Merno mesto:";
        d.appendChild(l);
        
        let select = document.createElement("select");
        select.className="selectMernoMesto";
        d.appendChild(select);

        var op;
        var lmesta = [];
        fetch("https://localhost:5001/CityMun/getcitymunmesta/"+document.querySelector(".citymunselect").value)
        .then(p=>{
            p.json().then(mesta => {
                mesta.forEach(mesto => {
                    for(var i in mesto)
                    {
                        lmesta.push(mesto[i]);
                    }
                })
        
                let duzina = lmesta.length;
                for(var i=1; i<duzina; i+=5)
                {
                    op = document.createElement("option");
                    op.value=lmesta[i];
                    op.innerHTML = lmesta[i];
                    select.appendChild(op);
                }       
        
            })
        })


        d = document.createElement("div");
        d.clas = "divE1";
        divGrad.appendChild(d);
        
        let input = document.createElement("input");
        input.type = "checkbox";
        input.className="checkWeather";    
        d.appendChild(input);

        l = document.createElement("label");    
        l.innerHTML="Weather";
        d.appendChild(l);
        
        d = document.createElement("div");
        d.clas = "divE1";
        divGrad.appendChild(d);
        
        input = document.createElement("input");
        input.type = "checkbox";
        input.className="checkAirQ";    
        d.appendChild(input);

        l = document.createElement("label");    
        l.innerHTML="Air quality";
        d.appendChild(l);
        
        let btn = document.createElement("button");
        btn.className = "dugme1";
        btn.innerHTML="Show selected data";
        divGrad.appendChild(btn);
        btn.onclick = (ev) => {

            let divData = document.createElement("div");
            divData.className="divData";
            host.appendChild(divData);
            
            h = document.createElement("h3");
            h.innerHTML = document.querySelector(".citymunselect").value;
            divData.appendChild(h);

            let d = document.createElement("div");
            d.clas = "divE1";
            divData.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Merno mesto: " + document.querySelector(".selectMernoMesto").value;
            d.appendChild(l);

            if(document.querySelector(".checkAirQ").checked)
            {
                d = document.createElement("div");
                d.clas = "divE1";
                divGrad.appendChild(d);

                l = document.createElement("label");
                l.class = "airq"
                l.innerHTML="Qindex: ";
                divData.appendChild(l);

                d = document.createElement("div");
                d.clas = "divE1";
                divData.appendChild(d);

                l = document.createElement("label");
                l.class = "airq"
                l.innerHTML="PM2.5: ";
                d.appendChild(l);
            }
            if(document.querySelector(".checkWeather").checked)
            {

                d = document.createElement("div");
                d.clas = "divE1";
                divData.appendChild(d);
    
                l = document.createElement("label");
                l.class = "weather"
                l.innerHTML="Temperature: ";
                d.appendChild(l);
    
                d = document.createElement("div");
                d.clas = "divE1";
                divData.appendChild(d);
    
                l = document.createElement("label");
                l.class = "weather"
                l.innerHTML="Humidity: ";
                divData.appendChild(l);
    
                d = document.createElement("div");
                d.clas = "divE1";
                divData.appendChild(d);
    
                l = document.createElement("label");
                l.class = "weather"
                l.innerHTML="Short: ";
                divData.appendChild(l);
            }          




            btn = document.createElement("button");
            btn.className = "dugme1";
            btn.innerHTML="Close";
            divData.appendChild(btn);
            btn.onclick = (ev) => {
                host.removeChild(divData);
            };

            
        };

        btn = document.createElement("button");
        btn.className = "dugme1";
        btn.innerHTML="Edit data";
        divGrad.appendChild(btn);
        btn.onclick = (ev) => {
            let divGrad = document.createElement("div");
            divGrad.className="divGrad";
            host.appendChild(divGrad);
            
            let h = document.createElement("h3");
            h.innerHTML = document.querySelector(".citymunselect").value;
            divGrad.appendChild(h);

            let d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            let l = document.createElement("label");
            l.innerHTML="Merno mesto: " + document.querySelector(".selectMernoMesto").value;
            divGrad.appendChild(l);
            
            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Qindex:";
            d.appendChild(l);
            
            let input = document.createElement("input");
            input.className="inputQindex";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="PM2.5:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputPMtwo";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="T:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputTemperature";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Humidity:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputHumidity";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Ukratko:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputUkratko";
            d.appendChild(input);

            btn = document.createElement("button");
            btn.className = "dugme1";
            btn.innerHTML="Edit data";
            divGrad.appendChild(btn);
            btn.onclick = (ev) => {

                let weatherdata  = {
                    ukratko: document.querySelector(".inputUkratko").value,
                    temperature: document.querySelector(".inputTemperature").value,
                    humidity: document.querySelector(".inputHumidity").value 
                }

                let airqdata = {
                    qindex: document.querySelector(".inputQindex").value ,
                    pMtwo: document.querySelector(".inputPMtwo").value
                }                

                let mernomesto = {
                    ime: document.querySelector(".selectMernoMesto").value,                    
                }
    
                fetch("https://localhost:5001/MernoMesto/updateweatherdata/" + mernomesto.ime + "/"+ weatherdata.ukratko + "/" + weatherdata.temperature + "/" + weatherdata.humidity,
                    {
                        method:"PUT"                                        
                    });

                fetch("https://localhost:5001/MernoMesto/updateairqdata/" + mernomesto.ime + "/" + airqdata.qindex + "/" + airqdata.pMtwo,
                    {
                        method:"PUT"                                        
                    });

            };

            btn = document.createElement("button");
            btn.className = "dugme1";
            btn.innerHTML="Close";
            divGrad.appendChild(btn);
            btn.onclick = (ev) => {
                host.removeChild(divGrad);
            };            
        };

        btn = document.createElement("button");
        btn.className = "dugme1";
        btn.innerHTML="Add data";
        divGrad.appendChild(btn);
        btn.onclick = (ev) => {

            let divGrad = document.createElement("div");
            divGrad.className="divGrad";
            host.appendChild(divGrad);
            
            let h = document.createElement("h3");
            h.innerHTML = document.querySelector(".citymunselect").value;
            divGrad.appendChild(h);

            let d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);
            
            let l = document.createElement("label");
            l.innerHTML="Merno mesto:";
            d.appendChild(l);
            
            let input = document.createElement("input");
            input.className="inputMernoMesto";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Qindex:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputQindex";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="PM2.5:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputPMtwo";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="T:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputTemperature";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Humidity:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputHumidity";
            d.appendChild(input);

            d = document.createElement("div");
            d.clas = "divE1";
            divGrad.appendChild(d);

            l = document.createElement("label");
            l.innerHTML="Ukratko:";
            d.appendChild(l);
            
            input = document.createElement("input");
            input.className="inputUkratko";
            d.appendChild(input);

            btn = document.createElement("button");
            btn.className = "dugme1";
            btn.innerHTML="Add data";
            divGrad.appendChild(btn);
            btn.onclick = (ev) => {        

                let mernomesto = {
                    ime: document.querySelector(".inputMernoMesto").value,
                    weatherdata:{
                        ukratko: document.querySelector(".inputUkratko").value,
                        temperature: document.querySelector(".inputTemperature").value,
                        humidity: document.querySelector(".inputHumidity").value 
                    } ,
                    airqdata: {
                        qindex: document.querySelector(".inputQindex").value ,
                        pMtwo: document.querySelector(".inputPMtwo").value
                    },
                    citymun:{
                        ime: document.querySelector(".citymunselect").value

                    }                                       
                }
                fetch("https://localhost:5001/MernoMesto/adddata",
                {
                    method:"POST",
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },
                    body: JSON.stringify(mernomesto)                
                });
                       
                

            };

            btn = document.createElement("button");
            btn.className = "dugme1";
            btn.innerHTML="Close";
            divGrad.appendChild(btn);
            btn.onclick = (ev) => {
                host.removeChild(divGrad);
            };            
        };

        btn = document.createElement("button");
        btn.className = "dugme1";
        btn.innerHTML="Delete data";
        divGrad.appendChild(btn);
        btn.onclick = (ev) => { 

            fetch("https://localhost:5001/MernoMesto/deletemesto/" + document.querySelector(".selectMernoMesto").value,
                    {
                        method:"DELETE",
                                        
                    });



        }
        

        btn = document.createElement("button");
        btn.className = "dugme1";
        btn.innerHTML="Close";
        divGrad.appendChild(btn);
        btn.onclick = (ev) => {
            host.removeChild(divGrad);
        };
    }

    static crtajFormuZaDodavanje(host)
    {

        let divNoviGrad = document.createElement("div");
        divNoviGrad.className="divNoviGrad";
        host.appendChild(divNoviGrad);
        
        let h = document.createElement("h5");
        h.innerHTML = "Dodavanje grada/opstine:"
        divNoviGrad.appendChild(h);
        
        let l = document.createElement("label");
        l.innerHTML="Ime:";
        divNoviGrad.appendChild(l);
        
        let input = document.createElement("input");
        input.className="inputIme";
        divNoviGrad.appendChild(input);
        
        l = document.createElement("label");
        l.innerHTML="Zip code:";
        divNoviGrad.appendChild(l);
        
        input = document.createElement("input");
        input.className="inputZipcode";
        divNoviGrad.appendChild(input);
        
        let btn = document.createElement("button");
        btn.className = "dugme1";
        btn.innerHTML="Add City/Mun";
        divNoviGrad.appendChild(btn);
        btn.onclick = (ev) => {
            
            let citymun  = {
                ime: document.querySelector(".inputIme").value,
                ziPcode: document.querySelector(".inputZipcode").value 
            }

            fetch("https://localhost:5001/CityMun/addcitymun",
                {
                    method:"POST",
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                      },
                    body: JSON.stringify(citymun)                
                });            

            host.removeChild(divNoviGrad);
        };
        btn = document.createElement("button");
        btn.className = "dugme1";
        btn.innerHTML="Close";
        divNoviGrad.appendChild(btn);
        btn.onclick = (ev) => {
            host.removeChild(divNoviGrad);
        };
    }
}