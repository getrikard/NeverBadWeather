const appContext = {
    model: {
        page: 'main',
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
            const updateFunction = this.updateFunctions[page];
            updateFunction();
        }
    }
};
appContext.model.subscribe(appContext.view.update);
