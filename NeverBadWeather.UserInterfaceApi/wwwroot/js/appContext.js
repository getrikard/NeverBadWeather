const appContext = {
    model: {
        page: 'main',
        time: (function() {
            const now = new Date();
            const hours = now.getHours();
            return {
                date: now.toISOString().substr(0, 10),
                from: hours+1,
                to: 20,
            };
        })(),
        hasChanged() {
            if (this.callback) {
                this.callback();
            }
        },
        subscribe(callback) {
            this.callback = callback;
        }
    },
    view: {
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
    }
};
appContext.model.subscribe(appContext.view.update);
