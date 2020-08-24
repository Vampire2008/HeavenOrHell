<template>
	<b-card no-body>
		<div v-if="preparing" key="loading">
			<b-card-body>
				<b-row>
					<b-col class="text-center">
						<h4>Preparing...</h4>
					</b-col>
				</b-row>
				<b-row class="my-4">
					<b-col>
						<Loader></Loader>
					</b-col>
				</b-row>
			</b-card-body>
		</div>
		<div v-else key="loaded">
			<b-card-header class="text-center">
				<b-row>
					<b-col>
						<template
							v-if="currentStep < steps.length"
						>Step {{ currentStep+1 }} of {{ steps.length }}: {{ steps[currentStep].name }}</template>
						<template v-else>Results</template>
					</b-col>
				</b-row>
				<b-row>
					<b-col>
						<b-progress :max="steps.length" :value="currentStep"></b-progress>
					</b-col>
				</b-row>
			</b-card-header>
			<b-card-body>
				<b-row>
					<b-col>
						<template v-if="currentStep < steps.length">
							<!--<keep-alive>-->
							<component ref="currentComponent" :is="steps[currentStep].component" @submited="submited"></component>
							<!--</keep-alive>-->
						</template>
						<template v-else>
							<Result></Result>
						</template>
					</b-col>
				</b-row>
				<b-row v-if="currentStep < steps.length">
					<b-col cols="1">
						<b-button type="button" v-if="currentStep > 0" variant="secondary" @click="back">Back</b-button>
					</b-col>
					<b-col cols="2" offset="10" class="text-right">
						<b-button type="button" variant="success" @click="next" :disabled="processing">
							<b-spinner small label="Processing..." v-if="processing"></b-spinner>
							{{ currentStep == steps.length-1 ? "Finish" : "Next" }}
						</b-button>
					</b-col>
				</b-row>
			</b-card-body>
		</div>
	</b-card>
</template>

<script lang="ts">
	import Vue from "vue";
	import PersonForm from "@/components/PersonForm.vue";
	import Gluttony from "@/components/Gluttony.vue";
	import Greed from "@/components/Greed.vue";
	import Sloth from "@/components/Sloth.vue";
	import Wrath from "@/components/Wrath.vue";
	import Envy from "@/components/Envy.vue";
	import Pride from "@/components/Pride.vue";
	import Lust from "@/components/Lust.vue";
	import Result from "@/components/Result.vue";
	import Loader from "@/components/Loader.vue";
	import { mapState } from "vuex";
	import { v4 } from "uuid";
	import axios from "axios";

	export default Vue.extend({
		components: {
			PersonForm,
			Gluttony,
			Greed,
			Sloth,
			Wrath,
			Envy,
			Pride,
			Lust,
			Result,
			Loader,
		},
		data() {
			return {
				steps: [
					{
						name: "Personal info",
						component: PersonForm,
					},
					{
						name: "Gluttony",
						component: Gluttony,
					},
					{
						name: "Greed",
						component: Greed,
					},
					{
						name: "Sloth",
						component: Sloth,
					},
					{
						name: "Wrath",
						component: Wrath,
					},
					{
						name: "Envy",
						component: Envy,
					},
					{
						name: "Pride",
						component: Pride,
					},
					{
						name: "Lust",
						component: Lust,
					},
				],
				preparing: true,
				currentStep: 0,
				processing: false,
			};
		},
		computed: {
			...mapState(["uuid"]),
		},
		methods: {
			next() {
				this.processing = true;
				((this.$refs.currentComponent as unknown) as {
					submit: () => boolean;
				}).submit();

				// if (
				// 	!((this.$refs.currentComponent as unknown) as {
				// 		submit: () => boolean;
				// 	}).submit()
				// )
				// 	return;
				// // if (this.currentStep + 1 == this.steps.length) {
				// // 	//TODO: Finish logic
				// // 	return;
				// // }
				// this.currentStep++;
			},
			back() {
				if (this.currentStep - 1 < 0) return;
				this.currentStep--;
			},
			newUuid() {
				const uuid = v4();
				this.$store.commit("saveUuid", uuid);
				sessionStorage.setItem("userUuid", uuid);
				this.preparing = false;
			},
			submited(result: boolean) {
				this.processing = false;
				if (result) {
					this.currentStep++;
				}
			},
		},
		mounted() {
			const uuid = sessionStorage.getItem("userUuid");
			if (!uuid) {
				this.newUuid();
				return;
			}
			this.$store.commit("saveUuid", uuid);
			axios
				.get("/api/survey", {
					params: {
						uuid,
					},
				})
				.then((response) => {
					this.$store.commit("loadState", response.data);
					this.currentStep = response.data.step;
					this.preparing = false;
				})
				.catch((error) => {
					if (error.response && error.response.status === 404) {
						this.preparing = false;
						return;
					}
					if (error.message === "Network Error") {
						alert("No connection");
						return;
					}
					console.error(error.toJSON());
					//Old UUID cause problem, so I create new one and think this is new survey
					this.preparing = false;
					// this.newUuid();
				});
		},
	});
</script>
