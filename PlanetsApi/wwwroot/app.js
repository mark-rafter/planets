const Index = {
    data() {
        return {
            planetInfo: null,
            planetNames: []
        }
    },
    methods: {
        async updatePlanetInfo(planetName) {
            const planetInfoResponse = await fetch(`/planet/${planetName}`);
            this.planetInfo = planetInfoResponse.ok ? await planetInfoResponse.json() : null;
        }
    },
    async created() {
        const planetsResponse = await fetch('/planet');
        this.planetNames = await planetsResponse.json();
    }
};

const app = Vue.createApp(Index);

app.component('planet-info', {
    props: {
        planetInfo: Object
    },
    template: `
        <h3>{{ planetInfo.name }}</h3>
        <img src="{{ planetInfo.imageUrl }}" />
        <ul>
            <li>Distance from the sun: {{ planetInfo.distance }}</li>
            <li>Mass: {{ planetInfo.mass }}</li>
            <li>Diameter: {{ planetInfo.diameter }}</li>
        </ul>`
});

app.mount('#app');