
<script setup lang="ts">
defineProps<{ auteur: string; texte: string }>()
</script>

<template>
  <footer class="signature">
    <p>{{ texte }}</p>
  </footer>
</template>
