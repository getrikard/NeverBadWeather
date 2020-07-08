appContext.view.add('main', function () {
    const time = appContext.model.inputs.weatherRecommendation.time;
    document.getElementById('app').innerHTML = `
        <small><a href="javascript:goTo('rules')">Rediger klesinnstillingene</a></small>

        <hr/>

        <h3>Aldri dårlig vær!</h3>

        Hvilken dag vil du ha klesråd for? <br/>
        <input type="date" oninput="appContext.model.date = this.value" value="${time.date}"/><br/>
        Hvilken tidsperiode?<br/>
        Fra  
        <span class="timeStepUpDown" onclick="changeTime('from',-1)">▼</span
        ><span class="timeStepUpDown">kl. ${time.from}</span
        ><span class="timeStepUpDown" onclick="changeTime('from',+1)">▲</span>
        til 
        <span class="timeStepUpDown" onclick="changeTime('to',-1)">▼</span
        ><span class="timeStepUpDown">kl. ${time.to}</span
        ><span class="timeStepUpDown" onclick="changeTime('to',+1)">▲</span>
        <br/>

        <button onclick="getClothingRecommendation()">Få klesanbefaling!</button>
    `;
});