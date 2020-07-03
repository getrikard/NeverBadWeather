async function updateRule() {
    const ruleEdit = appContext.model.inputs.ruleEdit;
    const obj = ruleEdit.obj;
    const isBoth = obj.weatherType === null || obj.weatherType === 'both';
    const rule = {
        id: obj.id,
        isRaining: isBoth ? null : obj.weatherType === 'rain',
        fromTemperature: obj.temperature.from,
        toTemperature: obj.temperature.to,
        clothes: obj.clothes,
    };
    const isSuccess = await axios.post('/api/clothingRule', rule);
}