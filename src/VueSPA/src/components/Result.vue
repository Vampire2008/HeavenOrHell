<template>
	<div>
		<transition-group name="fade">
			<div v-if="ajaxInProcess" key="loading">
				<b-row>
					<b-col class="text-center">
						<h4>Doing some magic...</h4>
					</b-col>
				</b-row>
				<b-row class="my-4">
					<b-col>
						<Loader></Loader>
					</b-col>
				</b-row>
			</div>
			<div v-else key="show">
				<b-row>
					<b-col class="text-center">
						<h4>You will go to</h4>
					</b-col>
				</b-row>
				<b-row>
					<b-col class="text-center">
						<template v-if="result === afterLifeTypes.Heaven">
							<h1>Heaven</h1>
						</template>
						<template v-if="result === afterLifeTypes.Hell">
							<h1>Hell</h1>
						</template>
						<template v-if="result === afterLifeTypes.Valhalla">
							<h1>Valhalla</h1>
						</template>
						<template v-if="result === afterLifeTypes.Hel">
							<h1>Hel</h1>
						</template>
					</b-col>
				</b-row>
			</div>
		</transition-group>
	</div>
</template>

<script lang="ts">
	import Vue from "vue";
	import AfterLifeType from "@/models/AfterLifeType";
	import Loader from "./Loader.vue";
	import Axios from "axios";

	export default Vue.extend({
		components: {
			Loader,
		},
		data(): {
			ajaxInProcess: boolean;
			afterLifeTypes: typeof AfterLifeType;
			result: AfterLifeType;
		} {
			return {
				ajaxInProcess: true,
				afterLifeTypes: AfterLifeType,
				result: AfterLifeType.Heaven,
			};
		},
		mounted() {
			Axios.get("/api/survey/GetResult", {
				params: {
					uuid: this.$store.state.uuid,
				},
			})
				.then((response) => {
					this.result = response.data.result;
					this.ajaxInProcess = false;
					sessionStorage.clear();
				})
				.catch((error) => {
					alert("Something goes wrong");
					console.error(error.toJSON());
				});
		},
	});
</script>
