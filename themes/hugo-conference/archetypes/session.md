---
title: "{{ replace .Name "-" " " | title }}"
speaker: ""
---

**Insert Lead paragraph here.**

## New Cool Posts

{{ range first 100 ( where .Site.RegularPages "Type" "cool" ) }}
* {{ .Title }}
{{ end }}
