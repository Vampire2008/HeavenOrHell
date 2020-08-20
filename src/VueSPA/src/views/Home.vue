<template>
	<!-- <div class="home">
		<img alt="Vue logo" src="../assets/logo.png" />
		<HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />
	</div>-->
	<b-row>
		<b-col>
			<b-jumbotron header="Where will you go? Heaven or Hell?" lead="Take out survey and find out!">
				<b-button to="/survey" variant="primary">Survey</b-button>
			</b-jumbotron>
		</b-col>
	</b-row>
</template>

<script lang="ts">
	import Vue from "vue";
	// import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src

	export default Vue.extend({
		components: {
			// HelloWorld,
		},
	});
</script>
