<style>
  :root {
    --bg: #1f2328;
    --surface: #2b3036;
    --ink: #f3f4f6;
    --muted: #c3c7ce;
    --line: #454b54;
    --accent: #2f7d75;
    --accent-dark: #215e59;
    --warm: #f3b562;
    --soft: #243a38;
    --shadow: 0 14px 34px rgba(0, 0, 0, 0.28);
  }

  .docs-page {
    max-width: 1120px;
    margin: 0 auto;
    padding: 32px 18px 56px;
    background: var(--bg);
    color: var(--ink);
    font-family: Inter, ui-sans-serif, system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif;
    line-height: 1.6;
  }

  .docs-hero {
    display: grid;
    grid-template-columns: minmax(0, 1.5fr) minmax(260px, 0.8fr);
    gap: 28px;
    align-items: stretch;
    padding: 34px;
    border: 1px solid var(--line);
    border-radius: 8px;
    background: var(--surface);
    box-shadow: var(--shadow);
  }

  .docs-eyebrow {
    margin: 0 0 10px;
    color: var(--accent-dark);
    font-size: 0.8rem;
    font-weight: 800;
    letter-spacing: 0.08em;
    text-transform: uppercase;
  }

  .docs-hero h1 {
    margin: 0;
    max-width: 780px;
    font-size: clamp(2.25rem, 5vw, 4.25rem);
    line-height: 1;
    letter-spacing: 0;
  }

  .docs-lead {
    max-width: 760px;
    margin: 18px 0 0;
    color: var(--muted);
    font-size: 1.08rem;
  }

  .docs-actions {
    display: flex;
    flex-wrap: wrap;
    gap: 12px;
    margin-top: 26px;
  }

  .docs-button {
    display: inline-flex;
    align-items: center;
    min-height: 44px;
    padding: 0 16px;
    border: 1px solid var(--accent);
    border-radius: 6px;
    background: var(--accent);
    color: #ffffff !important;
    font-weight: 800;
    text-decoration: none;
  }

  .docs-button.secondary {
    background: transparent;
    color: var(--accent-dark) !important;
  }

  .docs-meta {
    display: grid;
    gap: 12px;
    align-content: start;
    padding: 22px;
    border: 1px solid rgba(47, 125, 117, 0.2);
    border-radius: 8px;
    background: rgba(43, 48, 54, 0.78);
  }

  .docs-meta-item {
    padding-bottom: 12px;
    border-bottom: 1px solid var(--line);
  }

  .docs-meta-item:last-child {
    padding-bottom: 0;
    border-bottom: 0;
  }

  .docs-meta strong {
    display: block;
    margin-bottom: 2px;
    color: var(--ink);
    font-size: 0.92rem;
  }

  .docs-meta span {
    color: var(--muted);
    font-size: 0.95rem;
  }

  .docs-section {
    margin-top: 34px;
  }

  .docs-section h2 {
    margin: 0 0 14px;
    font-size: 1.55rem;
    letter-spacing: 0;
  }

  .docs-grid {
    display: grid;
    grid-template-columns: repeat(3, minmax(0, 1fr));
    gap: 16px;
  }

  .docs-card {
    min-height: 220px;
    padding: 22px;
    border: 1px solid var(--line);
    border-radius: 8px;
    background: var(--surface);
    box-shadow: 0 8px 22px rgba(0, 0, 0, 0.2);
  }

  .docs-card h3 {
    margin: 0 0 10px;
    font-size: 1.15rem;
  }

  .docs-card p {
    margin: 0 0 16px;
    color: var(--muted);
  }

  .docs-card a {
    color: var(--accent-dark);
    font-weight: 800;
  }

  .docs-flow {
    display: grid;
    grid-template-columns: repeat(5, minmax(120px, 1fr));
    gap: 10px;
    margin-top: 14px;
  }

  .docs-step {
    position: relative;
    padding: 16px;
    border: 1px solid rgba(47, 125, 117, 0.22);
    border-radius: 8px;
    background: var(--soft);
    font-weight: 800;
    text-align: center;
  }

  .docs-table {
    width: 100%;
    border-collapse: collapse;
    overflow: hidden;
    border: 1px solid var(--line);
    border-radius: 8px;
    background: var(--surface);
  }

  .docs-table th,
  .docs-table td {
    padding: 14px 16px;
    border-bottom: 1px solid var(--line);
    text-align: left;
    vertical-align: top;
  }

  .docs-table th {
    background: #383f47;
    color: var(--ink);
  }

  .docs-table tr:last-child td {
    border-bottom: 0;
  }

  .docs-note {
    padding: 18px 20px;
    border-left: 5px solid var(--warm);
    border-radius: 8px;
    background: #3a3326;
    color: var(--muted);
  }

  @media (max-width: 820px) {
    .docs-hero,
    .docs-grid,
    .docs-flow {
      grid-template-columns: 1fr;
    }

    .docs-hero {
      padding: 24px;
    }

    .docs-card {
      min-height: auto;
    }
  }
</style>

<main class="docs-page">
<section class="docs-hero">
<div>
<p class="docs-eyebrow">Project documentation</p>
<h1>ProjectJ40</h1>
<p class="docs-lead">Mobile-first virtual pet simulator made in Unity, focused on modular architecture, mission progression, real-time needs, and a touch-based WebGL experience.</p>
<div class="docs-actions">
<a class="docs-button" href="../README.md">View README</a>
<a class="docs-button secondary" href="https://desireenavarrete.itch.io/projectj40">Playable build</a>
</div>
</div>
<aside class="docs-meta" aria-label="Project summary">
<div class="docs-meta-item">
<strong>Internal name</strong>
<span>J4vi - Put a Javi in your life</span>
</div>
<div class="docs-meta-item">
<strong>Type</strong>
<span>Virtual pet simulator</span>
</div>
<div class="docs-meta-item">
<strong>Engine</strong>
<span>Unity 2022.3.20f1, C#, WebGL</span>
</div>
<div class="docs-meta-item">
<strong>Main role</strong>
<span>Gameplay and Systems Programmer</span>
</div>
</aside>
</section>
<section class="docs-section">
<h2>Documentation index</h2>
<div class="docs-grid">
<article class="docs-card">
<h3>Design decisions</h3>
<p>Explains the project pillars, the decisions made for the FSM, missions, stats, notifications, and their trade-offs.</p>
<a href="./DesignDecisions.md">Abrir DesignDecisions.md</a>
</article>
<article class="docs-card">
<h3>Mechanics</h3>
<p>Summarizes the gameplay loop, character needs, touch interaction, activities, rooms, unlocks, and progression.</p>
<a href="./mechanics.md">Abrir mechanics.md</a>
</article>
<article class="docs-card">
<h3>Systems</h3>
<p>Describes the technical architecture: Needs System, Growth FSM, Quest System, Notification System, and module interaction.</p>
<a href="./systems.md">Abrir systems.md</a>
</article>
</div>
</section>
<section class="docs-section">
<h2>Main loop</h2>
<div class="docs-flow" aria-label="Main gameplay flow">
<div class="docs-step">Touch input</div>
<div class="docs-step">Activity</div>
<div class="docs-step">Stats</div>
<div class="docs-step">Mission</div>
<div class="docs-step">Unlock</div>
</div>
</section>
<section class="docs-section">
<h2>Key systems</h2>
<table class="docs-table">
<thead>
<tr>
<th>System</th>
<th>Responsibility</th>
<th>Document</th>
</tr>
</thead>
<tbody>
<tr>
<td>Needs System</td>
<td>Simulates hunger, sleep, and fun with continuous decay.</td>
<td><a href="./systems.md">systems.md</a></td>
</tr>
<tr>
<td>Activity System</td>
<td>Turns touch interactions into stat changes and progress.</td>
<td><a href="./mechanics.md">mechanics.md</a></td>
</tr>
<tr>
<td>Quest System</td>
<td>Organizes progression with reusable goals and clear actions.</td>
<td><a href="./DesignDecisions.md">DesignDecisions.md</a></td>
</tr>
<tr>
<td>Growth FSM</td>
<td>Controls character growth stages and transitions.</td>
<td><a href="./systems.md">systems.md</a></td>
</tr>
<tr>
<td>Notification System</td>
<td>Shows UI feedback with a FIFO queue to avoid spam.</td>
<td><a href="./DesignDecisions.md">DesignDecisions.md</a></td>
</tr>
</tbody>
</table>
</section>
<section class="docs-section">
<h2>Maintenance notes</h2>
<div class="docs-note">Keep this page as the entry point for the documentation. When new systems, mechanics, or decisions are added, link them here so the project path stays clear.</div>
</section>
</main>
