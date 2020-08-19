﻿function changeTime(timeField, change) {
    const model = appContext.model;
    const time = model.inputs.weatherRecommendation.time;
    time[timeField] = (time[timeField]+change+24)%24;
    model.hasChanged();
}

async function getClothingRecommendation() {
    const model = appContext.model;
    const time = model.inputs.weatherRecommendation.time;
    const location = model.position.coords;
    const request = {
        hourFrom: time.from,
        hourTo: time.to,
        latitude: location.latitude,
        longitude: location.longitude,
    };
    // console.log(request);
    const recommendation = await appContext.api.getClothingRecommendation(request);
    console.log(recommendation);
    model.recommendation = recommendation;
    model.hasChanged();
}