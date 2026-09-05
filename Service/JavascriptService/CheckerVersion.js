const thisVersion = "v0.2.1";
const urlVersion = "https://api.github.com/repos/Willian-Thdr/Fluxogrammer/releases/latest";
const http = require("http");
let actualVersion;
var needUpdate = false;

async function getVersion() {
    try {
        const require = await fetch(urlVersion);
        const data = await require.json();
        actualVersion = data.tag_name;

        execute(data.tag_name);
    } catch (error) {
        console.log(error);
    }
}

const server = http.createServer((req, res) => {
    if (req.url === "/version") {
        res.writeHead(200, {
            "Content-Type": "application/json"
        });

        res.end(JSON.stringify({
            "this version": thisVersion,
            "actual version": actualVersion,
            "need update": needUpdate,
        }, null, 4));

        return;
    }

    res.writeHead(404);
    res.end("Not Found");
});

server.listen(3000, () => {
    console.log("Servidor online: http://localhost:3000/version");
})

function execute(version) {
    if (thisVersion !== version) {
        needUpdate = true;
        console.log("Need update");
    }
}

getVersion();