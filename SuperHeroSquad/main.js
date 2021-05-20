fetch(
    'https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json'
)
    //.then((res) => console.log(res));
    .then((res) => res.json())
    //.then((data) => console.log(data));
    .then((data) => setHeroes(data));

function setHeroes({ squadName, homeTown, formed, members}) {
    document.body.insertAdjacentHTML(
        'afterbegin',
        `
        <h1>${squadName}</h1>
        <h2>HomeTown: ${homeTown} //Formed: ${formed}</h2>
        <div class="heroes">${setMembers(members)}</div>
        `
    )
}

function setMembers(members) {
    return members
        .map(
            (hero) => `<div>
            <h3>${hero.name}</h3>
            <p>secretIdentity: ${hero.secretIdentity}</p>
            <p>age: ${hero.age}</p>
            <p>superPowers:</p>
            <ul>
                ${setPowers(hero.powers)}
            </ul></div>
            `
        ).join(` `);
}

function setPowers(powers) {
    return powers.map(
        (power) => `<li>${power}</li>`
    ).join(` `);
}