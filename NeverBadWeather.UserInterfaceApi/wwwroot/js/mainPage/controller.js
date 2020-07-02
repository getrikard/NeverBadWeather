function changeTime(timeField, change) {
    const model = appContext.model;
    const time = model.inputs.weatherRecommendation.time;
    time[timeField] = (time[timeField]+change+24)%24;
    model.hasChanged();
}