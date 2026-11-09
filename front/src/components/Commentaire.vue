
<script setup lang="ts">
import { computed } from 'vue'

const props = defineProps<{ auteur: string; texte: string }>()
const apercu = computed(() => props.texte.slice(0, 200))
</script>

<template>
  <article class="commentaire">
    <!-- Le texte vient de l'éditeur riche : on garde la mise en forme -->
    <div class="corps" v-html="props.texte"></div>
  </article>
</template>
