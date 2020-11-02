const App = {
    data() {
        return {
            selectedPlanet: null,
            planetNames: []
        }
    },
    async created() {
        const planetsResponse = await fetch("/planet");
        this.planetNames = await planetsResponse.json();
    }
};

Vue.createApp(App).mount('#app');