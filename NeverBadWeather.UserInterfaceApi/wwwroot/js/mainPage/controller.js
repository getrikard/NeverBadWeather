function changeTime(timeField, change) {
    const model = appContext.model;
    const time = model.time;
    time[timeField] = (time[timeField]+change+24)%24;
    model.hasChanged();
}