import { useState, useEffect, useRef } from 'react';
import { Pie } from 'react-chartjs-2';
import { Chart, ArcElement, Tooltip, Legend } from 'chart.js';
import { HubConnectionBuilder } from "@microsoft/signalr";
import axios from 'axios';

Chart.register(ArcElement, Tooltip, Legend);

const colors = ['Primary', 'Secondary', 'Success', 'Danger', 'Warning', 'Info', 'Light', 'Dark'];

const options = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
        legend: {
            position: 'top',
        },
        title: {
            display: true,
            text: 'Button Clicks Distribution',
        },
    },
};

const Home = () => {

    const connectionRef = useRef();

    const [colorStats, setColorStats] = useState([]);

    useEffect(() => {
        const connectToHub = async () => {
            const connection = new HubConnectionBuilder().withUrl("/api/colorhub").build();
            await connection.start();
            connectionRef.current = connection;

            connection.on('colorStatsUpdate', colorStats => {
                setColorStats(colorStats);
            });
        }

        connectToHub();
    }, []);

    useEffect(() => {
        const loadColorStats = async () => {
            const { data } = await axios.get('/api/colorfight/getcolorstats');
            setColorStats(data);
        }

        loadColorStats();
    }, []);



    const getData = () => {
        const obj = colorStats.reduce((prev, curr) => {
            prev[curr.name] = curr.count;
            return prev;
        }, {});

        return colors.map(c => obj[c]);
    }

    const data = {
        labels: colors,
        datasets: [
            {
                label: '# of Clicks',
                data: getData(),
                backgroundColor: [
                    'rgb(13,110,253)',
                    '#6C757D',
                    '#198754',
                    '#DC3545',
                    '#FFC107',
                    '#0DCAF0',
                    '#F8F9FA',
                    '#212529',
                ]
            },
        ],
    };

    const onButtonClick = async color => {
        await axios.post('/api/colorfight/incrementcolor', { color });
    }

    return (
        <div className="text-center bg-dark text-light p-5" style={{ minHeight: '100vh' }}>
            <h1 className="my-4 display-4 text-warning">Welcome to ColorFight!</h1>
            <p className="lead mb-4">Duke it out and prove that your favorite color is the best! Click a button below to start the battle!</p>
            <div className="mb-4 p-4 bg-light rounded" style={{ height: 400, width: 400, margin: '0 auto' }}>
                {Boolean(colorStats.length) && <Pie data={data} options={options} /> }
            </div>
            <div className="d-flex flex-wrap justify-content-center p-3" style={{ backgroundColor: '#343a40', borderRadius: '0.5rem' }}>

                {colors.map(c => <button key={c} onClick={() => onButtonClick(c)} type="button" className={`btn btn-${c.toLowerCase()} m-2 btn-lg`}>{c}</button>)}


            </div>
            <div className="alert alert-success mt-4" role="alert">
                Click the buttons as many times as you want and see the pie chart update in real-time!
            </div>
        </div>
    );
};

export default Home;
