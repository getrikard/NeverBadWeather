appContext.view.add('main', function() {
    document.getElementById('app').innerHTML = `
        <h3>Aldri dårlig vær!</h3>

        Hvilken dag vil du ha klesråd for? <br/>
        <input type="date" oninput="appContext.model.date = this.value"/><br/>
        Hvilken tidsperiode 

    `;
});