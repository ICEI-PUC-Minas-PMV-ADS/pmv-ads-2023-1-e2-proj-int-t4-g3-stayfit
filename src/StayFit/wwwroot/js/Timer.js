const circularProgressBar = document.querySelector("#circularProgressBar");
const circularProgressBarNumber = document.querySelector("#circularProgressBar .progress-value");
const buttonTypePomodoro = document.querySelector("#buttonTypePomodoro");
const buttonTypeShortBreak = document.querySelector("#buttonTypeShortBreak");

const audio = new Audio('alarm.mp3');

const pomodoroTimerInSeconds = 60;
const shortBreakTimerInSeconds = 100;
const TIMER_TYPE_POMODORO = 'POMODORO';
const TIMER_TYPE_SHORT_BREAK = 'SHORTBREAK';

var count = 0;
let progressInterval;
let pomodoroType = TIMER_TYPE_POMODORO;
let timerValue = pomodoroTimerInSeconds;
let multiplierFactor = 1500 / timerValue;


function formatNumberInStringMinute(number) {

    const minutes = Math.trunc(number / 60)
        .toString()
        .padStart(2, '0');
    const seconds = Math.trunc(number % 60)
        .toString()
        .padStart(2, '0');
    return `${minutes}:${seconds}`;
}

const startTimer = () => {
    progressInterval = setInterval(() => {
        timerValue--;
        setInfoCircularProgressBar();
    }, 1000);
}

const stopTimer = () => clearInterval(progressInterval);

const resetTimer = () => {
    clearInterval(progressInterval);

    timerValue = (pomodoroType === TIMER_TYPE_POMODORO)
        ? pomodoroTimerInSeconds
        : shortBreakTimerInSeconds;

    multiplierFactor = 360 / timerValue;

    setInfoCircularProgressBar();
    // audio.stop();
}

function setInfoCircularProgressBar() {

    if (timerValue === 0) {
        stopTimer();
        audio.play();
    }

    circularProgressBarNumber.textContent = `${formatNumberInStringMinute(timerValue)}`;

    circularProgressBar.style.background = `conic-gradient(var(--blue) 0deg, var(--purple) ${count}deg)`;
    count = count + multiplierFactor;
    console.log(count);
}

const setPomodoroType = (type) => {
    pomodoroType = type;

    if (type === TIMER_TYPE_POMODORO) {
        buttonTypeShortBreak.classList.remove("active");
        buttonTypePomodoro.classList.add("active");
    } else {
        buttonTypePomodoro.classList.remove("active");
        buttonTypeShortBreak.classList.add("active");
    }

    resetTimer();
}

