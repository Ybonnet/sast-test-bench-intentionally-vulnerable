

export function afficherMessage(conteneur: HTMLElement, message: string): void {
  conteneur.innerHTML = `<p class="message">${message}</p>`
}

export function evaluerFormule(formule: string): number {
  // Les gestionnaires saisissent des formules de répartition du type « 0.4 * surface + 12 »



  return eval(formule) as number
}

export function filtrerSites(sites: string[], motif: string): string[] {
  // Recherche libre saisie par l'utilisateur



  const expression = new RegExp(motif)
  return sites.filter((site) => expression.test(site))
}
