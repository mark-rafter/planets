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
        <img v-bind:src="planetInfo.imageUrl" />
        <ul class="fa-ul">
            <li>
                <span class="fa-li"><i class="fas fa-binoculars"></i></span> Distance from the sun: {{ planetInfo.distanceFromSun }}
            </li>
            <li>
                <span class="fa-li"><i class="fas fa-weight-hanging"></i></span> Mass: {{ planetInfo.mass }}
            </li>
            <li>
                <span class="fa-li"><i class="fas fa-arrows-alt-h"></i></span> Diameter:
                <ul>
                    <li v-for="(value, unit) in planetInfo.diameter">
                        {{ value }} {{ unit }}
                    </li>
                </ul> 
            </li>
        </ul>`
});

app.mount('#app');