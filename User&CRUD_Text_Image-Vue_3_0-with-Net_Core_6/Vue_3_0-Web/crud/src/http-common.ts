import axios from 'axios'
export default axios.create({
	baseURL: "https://localhost:7076/api",
	headers: {
		"Content-Type": "application/json"
	},
	timeout: 5000
})