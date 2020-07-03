async function updateRule() {
    const ruleEdit = appContext.model.inputs.ruleEdit;
    const isBoth = ruleEdit.weatherType === null || ruleEdit.weatherType === 'both';
    let rule = {
        id: ruleEdit.id || null,
        isRaining: isBoth ? null : ruleEdit.weatherType === 'rain',
        fromTemperature: ruleEdit.temperature.from,
        toTemperature: ruleEdit.temperature.to,
        clothes: ruleEdit.clothes,
    };
    console.log(rule);
    try {
        const isSuccess = await axios.post('/api/clothingRule', rule);
    } catch (e) {
        console.log(e);
    }
}