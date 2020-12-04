const API = 'slotmachine';
const FIRST = `${API}/firstdraw`;
const SECOND = `${API}/seconddraw`;
const THIRD = `${API}/thirddraw`;
const RESULTS = `${API}/results`;
const SAVE = `${API}/saveresult`;

const draw_table = document.getElementById("draw-table");
const draw_button = document.getElementById("draw_button");
const res_table = document.getElementById("res-table");

function draw()
{
    draw_button.disabled = true;
    Promise.all([
        fetch(FIRST).then(res => res.text()),
        fetch(SECOND).then(res => res.text()),
        fetch(THIRD).then(res => res.text())
    ])
        .then(value => {
        draw_table.innerHTML = '';
        const row = document.createElement("tr");
        for(const result in value)
        {
            const cell = document.createElement("td");
            cell.innerText = value[result];
            row.appendChild(cell);
        }
        draw_table.appendChild(row);
        draw_button.disabled = false;
        return value;
    })
        .then((value) => {
            const set = new Set(value);
            if(set.size < 3)
            {
                fetch(SAVE, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        firstResult: value[0],
                        secondResult: value[1],
                        thirdResult: value[2],
                    })
                }).then(res => {
                    if(res.status === 400)
                    {
                        alert(res.text());
                    }
                    else
                    {
                        getResults();
                    }
                })
            }
    });
}

function getResults() {
    fetch(RESULTS)
        .then(res => res.json())
        .then(json => {
            res_table.innerHTML = '';
            for(const result of json)
            {
                const row = document.createElement("tr");
                const id = document.createElement("td");
                const first = document.createElement("td");
                const second = document.createElement("td");
                const third = document.createElement("td");
                
                id.innerText = result.id;
                first.innerText = result.firstResult;
                second.innerText = result.secondResult;
                third.innerText = result.thirdResult;
                
                row.appendChild(id);
                row.appendChild(first);
                row.appendChild(second);
                row.appendChild(third);
                res_table.appendChild(row);
            }
        })
    ;
}

getResults();