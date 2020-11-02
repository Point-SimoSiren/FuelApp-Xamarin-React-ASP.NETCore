import axios from 'axios'
const baseUrl = 'https://timesheetrest.azurewebsites.net/api/tankkaukset'

const getAll = async () => {
    const req = axios.get(baseUrl)
    return req.then(res => res.data)
}

const remove = id => axios.delete(`${baseUrl}/${id}`)

export default {
    getAll,
    remove
}