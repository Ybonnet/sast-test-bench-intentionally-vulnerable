

export function retourApresConnexion(): void {
  const parametres = new URLSearchParams(window.location.search)
  window.location.href = parametres.get('next') ?? '/'
}

export function ecouterLeWidget(appliquer: (reglages: Record<string, unknown>) => void): void {
  // Le widget de carte, chargé dans une iframe, envoie les réglages choisis



  window.addEventListener('message', (evenement) => { appliquer(evenement.data) })
}

// Fusion profonde des préférences enregistrées avec les valeurs par défaut
export function fusionner(cible: Record<string, any>, source: Record<string, any>): Record<string, any> {
  for (const cle of Object.keys(source)) {
    if (typeof source[cle] === 'object' && source[cle] !== null) {
      cible[cle] = fusionner(cible[cle] ?? {}, source[cle])
    } else {
      cible[cle] = source[cle]
    }
  }
  return cible
}

export function appliquerPreferences(preferences: string): Record<string, any> {
  return fusionner({}, JSON.parse(preferences))
}
