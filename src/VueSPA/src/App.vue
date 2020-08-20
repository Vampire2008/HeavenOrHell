<template>
	<div id="app">
		<b-navbar toggleable="lg" variant="light" class="border-bottom">
			<b-container>
				<b-navbar-brand to="/">Heaven or Hell</b-navbar-brand>
				<b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
				<b-collapse id="nav-collapse" is-nav>
					<b-navbar-nav>
						<b-nav-item to="/" active-class="active" exact>Home</b-nav-item>
						<b-nav-item to="survey" active-class="active">Survey</b-nav-item>
						<b-nav-item to="about" active-class="active">About</b-nav-item>
					</b-navbar-nav>
				</b-collapse>
			</b-container>
		</b-navbar>
		<!-- <div id="nav">
			<router-link to="/">Home</router-link>|
			<router-link to="/about">About</router-link>
		</div>-->
		<b-container class="py-3">
			<router-view />
		</b-container>
	</div>
</template>

<script lang="ts">
	import Vue from "vue";
	export default Vue.extend({
		created() {
			console.log("App started");
		},
	});
</script>

<style>
	#app {
		font-family: Avenir, Helvetica, Arial, sans-serif;
		-webkit-font-smoothing: antialiased;
		-moz-osx-font-smoothing: grayscale;
		/* text-align: center; */
		color: #2c3e50;
	}

	#nav {
		padding: 30px;
	}

	#nav a {
		font-weight: bold;
		color: #2c3e50;
	}

	#nav a.router-link-exact-active {
		color: #42b983;
	}
</style>
