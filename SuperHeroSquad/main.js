fetch(
    'https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json'
)
    .then((res) => res.json())
    .then((data) => setHeroes(data));

function setHeroes({ squadName, homeTown, formed, secretBase, active, members}) {
    document.body.insertAdjacentHTML(
        'afterbegin',
        `
        <h1>SquadName: ${squadName}</h1>
        <h2>HomeTown: ${homeTown} //Formed: ${formed}</h2>
        <h2>SecretBase: ${secretBase}</h2>
        <h2>Active: ${active}</h2>
        <div class="heroes">${setMembers(members)}</div>
        `
    )
}

function setMembers(members) {
    return members
        .map(
            (member) => `<div>
            <h3>${member.name}</h3>
            <p>SecretIdentity: ${member.secretIdentity}</p>
            <p>Age: ${member.age}</p>
            <p>SuperPowers:</p>
            <ul>
                ${setPowers(member.powers)}
            </ul></div>
            `
        ).join(` `);
}

function setPowers(powers) {
    return powers.map(
        (power) => `<li>${power}</li>`
    ).join(` `);
}