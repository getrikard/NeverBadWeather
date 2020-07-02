const appContext = {};

(async function () {
    const now = new Date();
    const hours = now.getHours();

    appContext.model = {
        page: 'main',
        time: {
            date: now.toISOString().substr(0, 10),
            from: hours + 1,
            to: 20,
        },
        hasChanged() {
            if (this.callback) {
                this.callback();
            }
        },
        subscribe(callback) {
            this.callback = callback;
        }
    };
    appContext.view = {
        updateFunctions: {},
        add(pageName, updateFunction) {
            this.updateFunctions[pageName] = updateFunction;
            if (appContext.model.page === pageName) {
                updateFunction();
            }
        },
        update() {
            const page = appContext.model.page;
            const updateFunction = appContext.view.updateFunctions[page];
            updateFunction();
        }
    };
    appContext.model.subscribe(appContext.view.update);

    const result = await axios.get('/api/clothingRule');
    console.log(result.data);
    appContext.model.rules = result.data;

})();

