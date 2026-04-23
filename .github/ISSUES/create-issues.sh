#!/bin/bash

# Script to create all 20 GitHub issues for DDD transition
# Usage: bash create-issues.sh

set -e

echo "Creating GitHub Issues for DDD Transition..."
echo "============================================="
echo ""

# Check if gh CLI is installed and authenticated
if ! command -v gh &> /dev/null; then
    echo "Error: GitHub CLI (gh) is not installed."
    echo "Install it from: https://cli.github.com/"
    exit 1
fi

# Check authentication
if ! gh auth status &> /dev/null; then
    echo "Error: Not authenticated with GitHub CLI."
    echo "Run: gh auth login"
    exit 1
fi

# Array of tasks with their details
declare -a tasks=(
    "task-01-setup-ddd-structure.md|DDD-transition,Phase-1,priority-high,architecture"
    "task-02-value-objects.md|DDD-transition,Phase-1,priority-high,domain"
    "task-03-user-aggregate.md|DDD-transition,Phase-1,priority-high,domain"
    "task-04-visit-aggregate.md|DDD-transition,Phase-1,priority-high,domain"
    "task-05-repository-interfaces.md|DDD-transition,Phase-1,priority-high,domain"
    "task-06-cqrs-commands.md|DDD-transition,Phase-2,priority-high,application"
    "task-07-cqrs-queries.md|DDD-transition,Phase-2,priority-high,application"
    "task-08-unit-of-work.md|DDD-transition,Phase-2,priority-high,infrastructure"
    "task-09-repository-implementations.md|DDD-transition,Phase-3,priority-high,infrastructure"
    "task-10-domain-event-handlers.md|DDD-transition,Phase-3,priority-medium,application"
    "task-11-refactor-controllers.md|DDD-transition,Phase-4,priority-high,api"
    "task-12-password-hashing-service.md|DDD-transition,Phase-3,priority-high,infrastructure,security"
    "task-13-authentication-service.md|DDD-transition,Phase-3,priority-high,infrastructure,security"
    "task-14-validation-pipeline.md|DDD-transition,Phase-4,priority-medium,application"
    "task-15-logging-monitoring.md|DDD-transition,Phase-4,priority-medium,infrastructure"
    "task-16-pagination-filtering.md|DDD-transition,Phase-5,priority-low,application"
    "task-17-integration-events.md|DDD-transition,Phase-5,priority-low,infrastructure"
    "task-18-database-migration.md|DDD-transition,Phase-5,priority-medium,infrastructure"
    "task-19-api-documentation.md|DDD-transition,Phase-5,priority-low,documentation"
    "task-20-performance-testing.md|DDD-transition,Phase-6,priority-low,testing"
)

# Get the directory where this script is located
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# Counter for created issues
created=0
failed=0

# Create each issue
for task_info in "${tasks[@]}"; do
    IFS='|' read -r filename labels <<< "$task_info"
    filepath="${SCRIPT_DIR}/${filename}"
    
    if [ ! -f "$filepath" ]; then
        echo "❌ File not found: $filename"
        ((failed++))
        continue
    fi
    
    # Extract title from the file (first line after ---)
    title=$(grep -m 1 "^title:" "$filepath" | sed 's/title: "\(.*\)"/\1/')
    
    # Remove YAML frontmatter from the body
    body=$(sed '1,/^---$/d' "$filepath" | sed '1,/^---$/d')
    
    echo "Creating issue: $title"
    
    # Create the issue
    if gh issue create \
        --title "$title" \
        --body "$body" \
        --label "$labels"; then
        echo "✅ Created: $title"
        ((created++))
    else
        echo "❌ Failed: $title"
        ((failed++))
    fi
    
    echo ""
    
    # Small delay to avoid rate limiting
    sleep 1
done

echo "============================================="
echo "Summary:"
echo "  Created: $created"
echo "  Failed: $failed"
echo "  Total: ${#tasks[@]}"
echo ""

if [ $failed -eq 0 ]; then
    echo "✅ All issues created successfully!"
    echo ""
    echo "Next steps:"
    echo "1. View issues: gh issue list --label DDD-transition"
    echo "2. Create a project board for tracking progress"
    echo "3. Assign issues to team members"
else
    echo "⚠️  Some issues failed to create. Please check the errors above."
    exit 1
fi
