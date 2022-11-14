import axios, { AxiosResponse } from 'axios';

axios.defaults.baseURL = process.env.CLIENT_API_URL;

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
	get: (url: string, params?: URLSearchParams) => axios.get(url, { params }).then(responseBody),
	post: (url: string, body: {}) => axios.post(url, body).then(responseBody),	
};

const GameSession = {
	create: (gameSession: any) => requests.post('gameSession', gameSession),	
};

const query = {
	GameSession,
};

export default query;