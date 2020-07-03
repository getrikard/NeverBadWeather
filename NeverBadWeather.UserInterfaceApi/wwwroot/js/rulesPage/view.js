appContext.view.add('rules', function () {
    const ruleEdit = appContext.model.inputs.ruleEdit;
    const temperature = ruleEdit.temperature;
    const weatherType = ruleEdit.weatherType || 'both';
    const weatherTypes = ruleEdit.weatherTypes;
    const updateText = ruleEdit.obj === null ? 'Legg til ny regel' : 'Oppdater regel';
    document.getElementById('app').innerHTML = `
        <small><a href="javascript:goTo('main')">Få klesanbefaling!</a></small>
        <hr/>
        <h3>Aldri dårlig vær!</h3>
        
        For temperaturer mellom 
        <span class="timeStepUpDown" onclick="changeTime('from',-1)">▼</span
        ><span class="timeStepUpDown">${temperature.from}°C</span
        ><span class="timeStepUpDown" onclick="changeTime('from',+1)">▲</span>
        og
        <span class="timeStepUpDown" onclick="changeTime('to',-1)">▼</span
        ><span class="timeStepUpDown">${temperature.to}°C</span
        ><span class="timeStepUpDown" onclick="changeTime('to',+1)">▲</span>
        for
        <select onchange="appContext.model.inputs.ruleEdit.weatherType=this.value">
            ${weatherTypes.map(wt => `
                <option ${wt.value === weatherType ? 'selected' : ''} value="${wt.value}">${wt.description}</option>
            `).join('')}
        </select>
        anbefales følgende klær: 
        <input type="text" oninput="appContext.model.inputs.ruleEdit.clothes=this.value" />

        <br/>
        <button onclick="updateRule()">${updateText}</button>        
        <br/>
    `;
});