const API_URL = 'http://localhost:5000/api/auth'

export async function signup(signupData) {
  const response = await fetch(`${API_URL}/signup`, {
    method: 'POST',

    headers: {
      'Content-Type': 'application/json',
    },

    body: JSON.stringify(signupData),
  })

  const data = await response.json()

  if (!response.ok) {
    throw new Error(data.message || 'Signup failed.')
  }

  return data
}