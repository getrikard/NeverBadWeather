async function updateRule() {
    const ruleEdit = appContext.model.inputs.ruleEdit;
    const isSuccess = await axios.post('/api/clothingRule', ruleEdit.obj);
}