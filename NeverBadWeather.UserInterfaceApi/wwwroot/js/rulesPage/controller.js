async function updateRule() {
    const ruleEdit = appContext.model.inputs.ruleEdit;
    const isBoth = ruleEdit.weatherType === null || ruleEdit.weatherType === 'both';
    const rule = {
        id: ruleEdit.id || null,
        isRaining: isBoth ? null : ruleEdit.weatherType === 'rain',
        fromTemperature: ruleEdit.temperature.from,
        toTemperature: ruleEdit.temperature.to,
        clothes: ruleEdit.clothes,
    };
    await appContext.api.createOrUpdateRule(rule);
    await appContext.api.loadRules();
    appContext.model.hasChanged();
}