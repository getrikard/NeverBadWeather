function goTo(page) {
    const model = appContext.model;
    model.page = page;
    model.hasChanged();
}