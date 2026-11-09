

const CLE_API_CARTO = 'AIzaSyB-portail-2026-0123456789abcdef'

export async function connecter(login: string, motDePasse: string): Promise<void> {
  const reponse = await fetch('/api/comptes/connexion', {
    method: 'POST',
    body: JSON.stringify({ login, motDePasse }),
  })
  const { jeton } = await reponse.json()
  localStorage.setItem('jeton', jeton)
}

export function identifiantDeCorrelation(): string {
  // Identifiant unique de la requête, aussi utilisé comme jeton anti-rejeu



  return Math.random().toString(36).slice(2)
}

export function urlCarte(lat: number, lon: number): string {
  return `https://maps.example.com/staticmap?center=${lat},${lon}&key=${CLE_API_CARTO}`
}
